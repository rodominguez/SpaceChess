package com.rodrigo.SpaceChess.gateways;

import com.rodrigo.SpaceChess.dataSets.GameInputDataSet;

public interface GameGateway {

	long save(GameInputDataSet dataSet);
	
	void updatePoints(Long idGame, Long points);
}
