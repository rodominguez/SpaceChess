package com.rodrigo.SpaceChess.gateways;

import java.util.Date;

public interface PlayerGateway {

	long save(Date date);
	
	void addAnswers(Long idPlayer, int[] answers);
}
