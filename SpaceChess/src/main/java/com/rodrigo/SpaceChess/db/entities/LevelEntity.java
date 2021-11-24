package com.rodrigo.SpaceChess.db.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import com.rodrigo.SpaceChess.dataSets.LevelInputDataSet;

@Entity
@Table(name = "levels")
public class LevelEntity {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private Long id;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@OnDelete(action = OnDeleteAction.CASCADE)
	@JoinColumn(name = "id_game", insertable = false, updatable = false)
	private GameEntity game;

	@Column(name = "id_game", nullable = false)
	private Long id_game;
	
	@Column(name = "points", nullable = false)
	private Long points;
	
	@Column(name = "time_to_complete")
	private Long timeToComplete;
	
	@Column(name = "index_level")
	private Integer indexLevel;
	
	public LevelEntity() {
		
	}
	
	public LevelEntity(LevelInputDataSet dataSet) {
		this.id_game = dataSet.idGame;
		this.points = dataSet.points;
		this.timeToComplete = dataSet.time;
		this.indexLevel = dataSet.index;
	}
}
