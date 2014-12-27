class CreateRooms < ActiveRecord::Migration
  def change
    create_table :rooms do |t|
      t.integer :external_id
      t.string :name_bg
      t.string :name_en
      t.integer :price

      t.timestamps
    end
  end
end
