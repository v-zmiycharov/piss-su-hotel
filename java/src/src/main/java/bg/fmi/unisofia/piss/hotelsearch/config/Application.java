package bg.fmi.unisofia.piss.hotelsearch.config;

import org.glassfish.jersey.server.ResourceConfig;
import org.glassfish.jersey.server.ServerProperties;

import bg.fmi.unisofia.piss.hotelsearch.db.DBUtil;

public class Application extends ResourceConfig {
	public Application() {
		// Validation errors won't be sent to the client.
		property(ServerProperties.BV_SEND_ERROR_IN_RESPONSE, true);
	    // @ValidateOnExecution annotations on subclasses won't cause errors.
	    property(ServerProperties.BV_DISABLE_VALIDATE_ON_EXECUTABLE_OVERRIDE_CHECK, true);
		
	    DBUtil.createTable();
	}
}
