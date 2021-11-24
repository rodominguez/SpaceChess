package com.rodrigo.SpaceChess.db.entities;

import java.util.Date;

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

import com.rodrigo.SpaceChess.dataSets.GameInputDataSet;

@Entity
@Table(name = "games")
public class GameEntity {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private Long id;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@OnDelete(action = OnDeleteAction.CASCADE)
	@JoinColumn(name = "id_player", insertable = false, updatable = false)
	private PlayerEntity player;

	@Column(name = "id_player", nullable = false)
	private Long id_player;
	
	@Column(name = "type", nullable = false)
	private int type;
	
	@Column(name = "points", nullable = false)
	private Long points;
	
	@Column(name = "date", nullable = false)
	private Date date;
	
	public GameEntity() {
		
	}
	
	public GameEntity(GameInputDataSet dataSet) {
		this.id_player = dataSet.idPlayer;
		this.type = dataSet.type;
		this.points = dataSet.points;
		this.date = dataSet.date;
	}
	
	public Long getId() {
		return id;
	}
	
	public void setPoints(Long points) {
		this.points = points;
	}
}
