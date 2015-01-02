package bg.fmi.unisofia.piss.hotelsearch.service;

import java.util.List;

import bg.fmi.unisofia.piss.hotelsearch.model.Hotel;

public interface HotelService {
	
	List<Hotel> getHotels(Integer stars, Integer location, Integer order);
}
