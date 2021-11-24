package com.rodrigo.SpaceChess.db.implementation;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.rodrigo.SpaceChess.dataSets.LevelInputDataSet;
import com.rodrigo.SpaceChess.db.entities.LevelEntity;
import com.rodrigo.SpaceChess.db.repositories.LevelRepository;
import com.rodrigo.SpaceChess.gateways.LevelGateway;

@Component
public class LevelImplementation implements LevelGateway{

	@Autowired
	private LevelRepository levelRepository;
	
	@Override
	public void save(LevelInputDataSet dataSet) {
		levelRepository.save(new LevelEntity(dataSet));
	}

}
