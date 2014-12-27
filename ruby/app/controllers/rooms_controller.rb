class RoomsController < ApplicationController
  before_action only: [:update, :index]

  # GET /rooms/
  def index
    @rooms = Room.all
  end

  # GET /rooms/update
  def update
    @room = Room.where(external_id: room_params[:external_id]).distinct  
    if @room.empty?
      @room = Room.new(room_params)
      @room.external_id = room_params[:external_id]
    else
      @room = @room[0]
    end
    @room.name_bg = room_params[:name_bg]
    @room.name_en = room_params[:name_en]
    @room.price = room_params[:price]
    
    respond_to do |format|
      if @room.save
        format.html { redirect_to "/rooms" }
        format.json { head :no_content }
      else
        format.html { redirect_to "/rooms", notice: "Not saved."}
        format.json { render json: @room.errors, status: :unprocessable_entity }
      end
    end
  end

  private
  
  # Never trust parameters from the scary internet, only allow the white list through.
  def room_params
    params.permit(:external_id, :name_bg, :name_en, :price)
  end
end
