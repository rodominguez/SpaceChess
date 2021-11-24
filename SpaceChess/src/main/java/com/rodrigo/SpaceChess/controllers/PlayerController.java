package com.rodrigo.SpaceChess.controllers;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.rodrigo.SpaceChess.gateways.PlayerGateway;

@RestController
public class PlayerController {
	
	@Autowired
	private PlayerGateway playerGateway;

	@GetMapping("/addPlayer/{stringDate}")
	long addPlayer(@PathVariable String stringDate) throws ParseException {
		Date date = new SimpleDateFormat("MM-dd-yyyy HH:mm:ss").parse(stringDate);
		return playerGateway.save(date);
	}
	
	@GetMapping("/addQuestions/{idPlayer}/{q1}/{q2}/{q3}/{q4}")
	void addQuestionAnswers(@PathVariable Long idPlayer, @PathVariable int q1, @PathVariable int q2,
			@PathVariable int q3, @PathVariable int q4) throws ParseException {
		int[] answers = {q1, q2, q3, q4};
		playerGateway.addAnswers(idPlayer, answers);
	}
}
