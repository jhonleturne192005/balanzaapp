package com.example.apppeso.data_response

import com.google.gson.annotations.SerializedName
import java.io.Serializable

data class pesos_response(
        val id_peso:Int,
        val peso_bruto:Float,
        val peso_actual: Float,
        val tara:Float,
        val fecha_actual:String) : Serializable

class DataR
        (
           @SerializedName("message") val message:String,
        ):Serializable