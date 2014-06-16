using UnityEngine;
using System.Collections;

public static class Parameters {

	/*
	 * Ac'a van los parematros de cada nivel, 
	 * dialogo del problema, opciones, opcion corecta, 
	 * sprites, respuesta de cada ingeniero, etc..
	 */

	private static string[] problems = new string[] { "Se necesita restablecer la energía en la facultad de Ingeniería. ¿Cuál de estos profesionales escogerías?" 
													, "Se encontraron muestras del virus T en el ed de química, pero este por ser radioactivo y peligroso debe ser manipulado y controlado por un objeto a distancia."};

	private static string[,] engineers = new string[,] { {"Electrónico", "Mecatrónico" , "Electricista"}
														,{"Mecanico", "Mecatrónico" , "Industrial"} };


	private static int[] correctAnswers = new int[] { 2, 1};

	private static string[,] engineersMessage = new string[,] 
	{ {	  " Hola, siento no poder ayudarte. Mi desempeño es óptimo en áreas de comunicación, antenas, y el trabajo con sistemas digitales. No manejo cargas eléctricas tan elevadas"
		, "oye, mis habilidades están en el área de robótica y de la automatización, y no tengo el conocimiento para trabajar cargas eléctricas tan elevadas. No puedo ayudarte."
		, "Que buena decisión. Mis conocimientos se enfocan en el área de instalaciones eléctricas de baja y alta tensión, transformadores, motores eléctricos, redes de distribución. Me da gusto poder ayudarte."
	  }
	, {   "Mensaje Mec'anico"
		, "Mensaje mecatronico" 
		, "mensaje industrial"
	  } 
	};





//*****************

	public static string getProblem(int level){
		return problems[level];
	}

	public static string getEngineer(int level, int option){
		return engineers [level, option];
	}

	public static int getCorrectAnswer(int level){
		return correctAnswers [level];
	}

	public static string getEngineersMessage(int level, int option){
		return engineersMessage [level, option];
	}

}
