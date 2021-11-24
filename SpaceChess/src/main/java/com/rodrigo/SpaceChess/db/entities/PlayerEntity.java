package com.rodrigo.SpaceChess.db.entities;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "players")
public class PlayerEntity {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private Long id;
	
	@Column(name = "date", nullable = false)
	private Date date;
	
	@Column(name = "question_1", nullable = false)
	private boolean question_1;
	
	@Column(name = "question_2", nullable = false)
	private boolean question_2;
	
	@Column(name = "question_3", nullable = false)
	private boolean question_3;
	
	@Column(name = "question_4", nullable = false)
	private boolean question_4;
	
	public PlayerEntity() {
		
	}
	
	public PlayerEntity(Date date) {
		this.date = date;
	}
	
	public Long getId() {
		return id;
	}
	
	public void setQuestions(int[] answers) {
		this.question_1 = answers[0] == 1;
		this.question_2 = answers[1] == 1;
		this.question_3 = answers[2] == 1;
		this.question_4 = answers[3] == 1;
	}
}
