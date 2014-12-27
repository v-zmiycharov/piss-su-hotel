class AddPaymentTypeToReservations < ActiveRecord::Migration
  def change
    add_column :reservations, :payment_type, :string
  end
end
