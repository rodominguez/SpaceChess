package com.rodrigo.SpaceChess.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.rodrigo.SpaceChess.dataSets.LevelInputDataSet;
import com.rodrigo.SpaceChess.gateways.LevelGateway;

@RestController
public class LevelController {

	@Autowired
	private LevelGateway levelGateway;
	
	@GetMapping("/addLevel/{idGame}/{points}/{time}/{index}")
	void addLevel(@PathVariable Long idGame, 
			@PathVariable Long points, @PathVariable Long time, @PathVariable Integer index) {
		LevelInputDataSet dataSet = buildDataSet(idGame, points, time, index);
		levelGateway.save(dataSet);
	}
	
	private LevelInputDataSet buildDataSet(Long idGame, Long points, Long time, Integer index) {
		LevelInputDataSet dataSet = new LevelInputDataSet();
		dataSet.idGame = idGame;
		dataSet.points = points;
		dataSet.time = time;
		dataSet.index = index;
		
		return dataSet;
	}
}
