package com.rodrigo.SpaceChess.db.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.rodrigo.SpaceChess.db.entities.LevelEntity;

public interface LevelRepository extends JpaRepository<LevelEntity, Long>{

}
