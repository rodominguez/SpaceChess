package com.rodrigo.SpaceChess.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HealthCheck {

	@GetMapping("/")
	void healthCheck() {
		return;
	}
}
