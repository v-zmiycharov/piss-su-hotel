class AddPaymentMethodToReservations < ActiveRecord::Migration
  def change
    add_column :reservations, :payment_method, :integer
  end
end
