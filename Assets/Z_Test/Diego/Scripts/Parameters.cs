using UnityEngine;
using System.Collections;

public static class Parameters {
	
	/*
	 * Aca van los parematros de cada nivel, 
	 * dialogo del problema, opciones, opcion corecta, 
	 * sprites, respuesta de cada ingeniero, etc..
	 */

	public static int LEVELS = 6;

	public static int[] plataformas = { 3, 5, 7, 9, 11, 15 };

	private static string[] problems = new string[] 
		{ "Se necesita restablecer la energía en la facultad de Ingeniería. ¿Cuál de estos profesionales escogerías?" 
		, "Se encontraron muestras del virus T en el ed de química, pero este por ser radioactivo y peligroso debe ser manipulado y controlado por un objeto a distancia."
		, "Animales atentan contra un edificio. Hay que verificar su estado:"
		, "Se necesita conocer la inversión que debe realizarse para las investigaciones sobre el virus y la producción de una cura. En caso de que no sea viable económicamente, se puede optar por destruir la zona afectada a través de artefactos explosivos. ¿A quién escogería para realizar estas investigaciones?"
		, "Se encontró una cura. Hay dos formas de distribuirla. Mediante un sistema de riego para que los animales beba de esa agua."
		, "Otra forma de distribuir la cura es haciendo plantaciones con hierbas que contengan la cura."
		};
	
	private static string[,] engineers = new string[,] 
		{ {"Electrónico"	, "Mecatrónico" , "Electricista"}
		, {"Mecanico"		, "Mecatrónico" , "Industrial"} 
		, {"Arquitecto"		, "Civil" 		, "Agricola"} 
		, {"Ing. químico"	, "Químico " 	, "Economista"} 
		, {"Agrícola"		, "Agrónomo" 	, "Civil"} 
		, {"Industrial"		, "Agrícola" 	, "Agrónomo"} 
		};
	
	
	private static int[] correctAnswers = new int[] { 2, 1, 1, 0, 0, 2};
	
	private static string[,] engineersMessage = new string[,] 
	{ {	  "Hola, siento no poder ayudarte. Mi desempeño es óptimo en áreas de comunicación, antenas, y el trabajo con sistemas digitales. No manejo cargas eléctricas tan elevadas"
		, "oye, mis habilidades están en el área de robótica y de la automatización, y no tengo el conocimiento para trabajar cargas eléctricas tan elevadas. No puedo ayudarte."
		, "Que buena decisión. Mis conocimientos se enfocan en el área de instalaciones eléctricas de baja y alta tensión, transformadores, motores eléctricos, redes de distribución. Me da gusto poder ayudarte."
	  }
	, {   "Lo siento, no tengo el conocimiento para la manipulación de mecanismos adistancia. Prefiero áreas que involucren motores decombustión, diseño, generación demovimiento y procesos de manufactura. "
		, "Perfecto! Conozco el área de la robótica y puedo ayudarte en la programación, control y manipulación de robots. Además recuerda mi interés en la automatización. " 
		, "Disculpa, no puedo ayudarte. Mi desempeño profesional se enfoca en sistemas integrados de personas, materiales, información, equipo y energía para la producción de bienes y servicios. "
	  }
	, {   "Hola, tengo algunos conocimientos que podrían ayudarte, pero sé que hay alguien que te prestaría una ayuda mejor. Búscame si necesitas ayuda con diseño y manejo del espacio habitable en las ciudades."
		, "Que buena elección. Me desempeño en todo lo relacionado con las obras de infraestructura como puentes, casas, edificios, autopistas, entre otras. Desde su diseño, construcción y futuro mantenimiento." 
		, "Disculpa! No tengo ni idea de lo que me pides. Puedo ayudarte en temas como control y automatización en la producción agropecuaria, y sistemas de riego y drenaje."
	  }
	, {   "Escoges bien. Mis conocimientos me permiten enfocarme en la preparación, la evaluación  técnica y económica de investigaciones y proyectos industriales de productos y procesos de transformación física, química o biológica."
		, "Lo siento, no puedo ayudarte. Me enfoco en la investigación científica, aplicación de la ciencia química al estudio del uso de los recursos, análisis y control químico en los procedimientos de fabricación. Pero no sé cómo evaluar económicamente la investigación." 
		, "Tengo conocimiento de los conceptos y estrategias de la economía y las finanzas, pero desconozco la complejidad de los proyectos e investigaciones químicas. Lo siento, pero alguien puede prestarte una mejor ayuda."
	  }
	, {   "Eliges bien, Mis conocimientos me permiten enfocarme en temas como control y automatización en la producción agropecuaria, sistemas de riego y drenaje."
		, "Lo lamento, no puedo ayudarte. Tengo excelentes conocimientos en la práctica de la agricultura y la ganadería. Y mi objetivo es mejorar la calidad de los procesos de la producción y la transformación de productos agrícolas y alimentarios." 
		, "Lo siento, no puedo ayudarte. Aunque puedo diseñar y construir un sistema de acueducto no tengo los conocimientos agropecuarios."
	  }
	, {   "Disculpa, no puedo ayudarte. Mi desempeño profesional se enfoca en sistemas integrados de personas, materiales, información, equipo y energía para la producción de bienes y servicios."
		, "¿Estás seguro?, te recuerdo que  mis conocimientos me permiten enfocarme en temas como control y automatización en la producción agropecuaria, sistemas de riego y drenaje. Necesitas alguien que conozca sobre la fertilización de suelos y siembra." 
		, "Estaba esperando que me eligieras. Los suelos, la fertilización, la siembra, y otras prácticas de la agricultura, son lo mío."
	  }

	};
	
	
	
	
	
	//*****************

	public static int getPlataformsForLevel(int level){
		return plataformas[level];
	}

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
