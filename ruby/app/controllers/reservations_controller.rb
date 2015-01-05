class ReservationsController < ApplicationController
  before_action :set_reservation, only: [:show, :edit, :update, :destroy, :confirm, :cancel]

  # GET /reservations
  # GET /reservations.json
  def index
    @reservations = Reservation.where(status: 'new').order(:create_date)
  end

  # GET /reservationshistory
  def history
    @reservations = Reservation.where.not(status: 'new').order(:create_date)
    @history = true
  end

  # GET /reservations/1
  # GET /reservations/1.json
  def show
  end

  # GET /reservations/new
  def new
    @reservation = Reservation.new
  end

  # GET /reservations/1/edit
  def edit
  end

  # GET /reservations/1/submit
  def confirm
    @reservation.status = 'confirmed'
    
    respond_to do |format|
      if @reservation.save()
        format.html { redirect_to reservations_url, notice: 'Reservation was successfully confirmed.' }
        format.json { render :show, status: :ok, location: @reservation }
      else
        format.html { render :edit }
        format.json { render json: @reservation.errors, status: :unprocessable_entity }
      end
    end
  end

  # GET /reservations/1/cancel
  def cancel
    @reservation.status = 'cancelled'
    
    respond_to do |format|
      if @reservation.save()
        format.html { redirect_to reservations_url, notice: 'Reservation was successfully cancelled' }
        format.json { render :show, status: :ok, location: @reservation }
      else
        format.html { render :edit }
        format.json { render json: @reservation.errors, status: :unprocessable_entity }
      end
    end
  end

  # POST /reservations
  # POST /reservations.json
  def create
    @reservation = Reservation.new(reservation_params)
    @reservation.status = 'new'
    @reservation.create_date = Time.now
    respond_to do |format|
      if @reservation.save
        @notice = I18n.t('reservation.success_text')
        format.html { render :success, notice: I18n.t('reservation.success_text') }
        format.json { render :success, status: :ok, location: @reservation }
      else
        format.html { render :new }
        format.json { render json: @reservation.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /reservations/1
  # PATCH/PUT /reservations/1.json
  def update
    respond_to do |format|
      if @reservation.update(reservation_params)
        format.html { redirect_to @reservation, notice: 'Reservation was successfully updated.' }
        format.json { render :show, status: :ok, location: @reservation }
      else
        format.html { render :edit }
        format.json { render json: @reservation.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /reservations/1
  # DELETE /reservations/1.json
  def destroy
    @reservation.destroy
    respond_to do |format|
      format.html { redirect_to reservations_url, notice: 'Reservation was successfully destroyed.' }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_reservation
      @reservation = Reservation.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def reservation_params
      params.require(:reservation).permit(:checkin, :checkout, :client_names, :client_email, :client_phone, :details,
        :clients_count, :breakfast, :payment_method, :room_id)
    end
end
