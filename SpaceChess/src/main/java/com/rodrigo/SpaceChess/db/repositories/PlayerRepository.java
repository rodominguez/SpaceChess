package com.rodrigo.SpaceChess.db.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.rodrigo.SpaceChess.db.entities.PlayerEntity;

public interface PlayerRepository extends JpaRepository<PlayerEntity, Long>{

}
