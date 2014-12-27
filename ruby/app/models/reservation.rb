class Reservation < ActiveRecord::Base
  enum payment_method: [:cash, :bank]
end
