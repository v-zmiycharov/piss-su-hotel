class CreateReservations < ActiveRecord::Migration
  def change
    create_table :reservations do |t|
      t.date :checkin
      t.date :checkout
      t.string :client_names
      t.string :client_email
      t.string :client_phone
      t.string :details
      t.integer :clients_count
      t.boolean :breakfast

      t.timestamps
    end
  end
end
