class AddUniqueIndexesToRooms < ActiveRecord::Migration
  def change
    add_index :rooms, :external_id, unique: true
  end
end
