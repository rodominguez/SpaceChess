package com.rodrigo.SpaceChess.db.implementation;

import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.rodrigo.SpaceChess.db.entities.PlayerEntity;
import com.rodrigo.SpaceChess.db.repositories.PlayerRepository;
import com.rodrigo.SpaceChess.gateways.PlayerGateway;

@Component
public class PlayerImplementation implements PlayerGateway{
	
	@Autowired
	private PlayerRepository playerRepository;

	@Override
	public long save(Date date) {
		return playerRepository.save(new PlayerEntity(date)).getId();
	}

	@Override
	public void addAnswers(Long idPlayer, int[] answers) {
		PlayerEntity player = playerRepository.getById(idPlayer);
		player.setQuestions(answers);
		playerRepository.save(player);
	}

}
