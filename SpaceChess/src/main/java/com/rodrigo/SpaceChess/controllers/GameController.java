package com.rodrigo.SpaceChess.controllers;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.rodrigo.SpaceChess.dataSets.GameInputDataSet;
import com.rodrigo.SpaceChess.gateways.GameGateway;

@RestController
public class GameController {

	@Autowired
	private GameGateway gameGateway;

	@GetMapping("/addGame/{idPlayer}/{type}/{points}/{date}")
	long addGame(@PathVariable Long idPlayer, @PathVariable Integer type,
			@PathVariable Long points,@PathVariable String date) throws ParseException {
		GameInputDataSet dataSet = buildDataSet(idPlayer, type, points, convertDate(date));
		return gameGateway.save(dataSet);
	}
	
	@GetMapping("/updateGame/{idGame}/{points}")
	void updatePoints(@PathVariable Long idGame, @PathVariable Long points) {
		gameGateway.updatePoints(idGame, points);
	}
	
	private Date convertDate(String stringDate) throws ParseException {
		return new SimpleDateFormat("MM-dd-yyyy HH:mm:ss").parse(stringDate);
	}
	
	private GameInputDataSet buildDataSet(Long idPlayer, Integer type, Long points, Date date) {
		GameInputDataSet dataSet = new GameInputDataSet();
		dataSet.idPlayer = idPlayer;
		dataSet.type = type;
		dataSet.points = points;
		dataSet.date = date;
		
		return dataSet;
	}
}
