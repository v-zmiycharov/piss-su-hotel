class AddRoomIdToReservations < ActiveRecord::Migration
  def change
    add_column :reservations, :room_id, :integer
    add_index :reservations, :room_id
  end
end
