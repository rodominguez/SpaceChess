package com.rodrigo.SpaceChess.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.rodrigo.SpaceChess.db.implementation.GameImplmentation;
import com.rodrigo.SpaceChess.db.implementation.LevelImplementation;
import com.rodrigo.SpaceChess.db.implementation.PlayerImplementation;
import com.rodrigo.SpaceChess.gateways.GameGateway;
import com.rodrigo.SpaceChess.gateways.LevelGateway;
import com.rodrigo.SpaceChess.gateways.PlayerGateway;

@Configuration
public class GatewayConfiguration {

	public @Bean PlayerGateway playerGateway() {
		return new PlayerImplementation();
	}
	
	public @Bean GameGateway gameGateway() {
		return new GameImplmentation();
	}
	
	public @Bean LevelGateway levelGateway() {
		return new LevelImplementation();
	}
}
