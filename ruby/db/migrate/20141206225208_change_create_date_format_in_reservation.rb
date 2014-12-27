class ChangeCreateDateFormatInReservation < ActiveRecord::Migration
  def change
    change_column :reservations, :create_date, :datetime
  end
end
