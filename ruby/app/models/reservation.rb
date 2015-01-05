class Reservation < ActiveRecord::Base
  enum payment_method: [:cash, :bank]
  belongs_to :room
end
