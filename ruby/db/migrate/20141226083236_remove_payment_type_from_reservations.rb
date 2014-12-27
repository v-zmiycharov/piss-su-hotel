class RemovePaymentTypeFromReservations < ActiveRecord::Migration
  def change
    remove_column :reservations, :payment_type, :string
  end
end
