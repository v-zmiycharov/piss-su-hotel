json.array!(@reservations) do |reservation|
  json.extract! reservation, :id, :checkin, :checkout, :client_names, :client_email, :client_phone, :details, :clients_count, :breakfast
  json.url reservation_url(reservation, format: :json)
end
