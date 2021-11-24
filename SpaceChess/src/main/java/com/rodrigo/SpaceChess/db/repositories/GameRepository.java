package com.rodrigo.SpaceChess.db.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.rodrigo.SpaceChess.db.entities.GameEntity;

public interface GameRepository extends JpaRepository<GameEntity, Long>{

}
