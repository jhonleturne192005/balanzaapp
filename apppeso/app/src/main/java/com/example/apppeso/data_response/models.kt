package com.example.apppeso.data_response

import java.io.Serializable

data class pesos_model(
    val id_peso:Int,
    val peso_bruto:Float,
    val peso_actual: Float,
    val tara:Float,
    val fecha_actual:String) : Serializable