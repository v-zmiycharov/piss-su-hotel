class AddCreateDateToReservations < ActiveRecord::Migration
  def change
    add_column :reservations, :create_date, :date
  end
end
