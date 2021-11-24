package com.rodrigo.SpaceChess.db.implementation;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.rodrigo.SpaceChess.dataSets.GameInputDataSet;
import com.rodrigo.SpaceChess.db.entities.GameEntity;
import com.rodrigo.SpaceChess.db.repositories.GameRepository;
import com.rodrigo.SpaceChess.gateways.GameGateway;

@Component
public class GameImplmentation implements GameGateway{

	@Autowired
	private GameRepository gameRepository;

	@Override
	public long save(GameInputDataSet dataSet) {
		return gameRepository.save(new GameEntity(dataSet)).getId();
	}

	@Override
	public void updatePoints(Long idGame, Long points) {
		GameEntity game = gameRepository.getById(idGame);
		game.setPoints(points);
		gameRepository.save(game);
	}
}
