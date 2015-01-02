package bg.fmi.unisofia.piss.hotelsearch.rest;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import bg.fmi.unisofia.piss.hotelsearch.service.HotelService;
import bg.fmi.unisofia.piss.hotelsearch.service.HotelServiceImpl;


@Path("hotels")
public class HotelController {
	
	private HotelService hotelService = new HotelServiceImpl();
	
	@GET
	@Path("/search")
	@Produces(MediaType.APPLICATION_JSON)
	public Response findHotels(@QueryParam("stars") Integer stars, 
			@QueryParam("location") Integer location, @QueryParam("order") Integer order) {
		
		return BaseController.buildResponse(hotelService.getHotels(stars, location, order));
	}
}
