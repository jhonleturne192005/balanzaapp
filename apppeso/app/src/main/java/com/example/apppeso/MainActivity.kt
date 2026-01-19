package com.example.apppeso

import android.os.Bundle
import android.util.Log
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.apppeso.UrlAPI.Companion.URL_SOCKET
import com.example.apppeso.data_response.data_socket
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import com.example.apppeso.data_response.pesos_model
import com.example.apppeso.databinding.ActivityMainBinding
import kotlinx.coroutines.withContext
import okhttp3.OkHttpClient
import kotlin.random.Random
import okhttp3.Request
import okhttp3.WebSocket

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()

        binding=ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val objsoc=data_socket("0,0","0,0","0,0");
        change_values(objsoc);
        prueba_code_save_data();
        init();
    }

    fun prueba_code_save_data() {
        CoroutineScope(Dispatchers.IO).launch {
            val pes=pesos_model(0,ramdom_num_float(1.0f,150.0f) ,ramdom_num_float(1.0f,150.0f),ramdom_num_float(1.0f,150.0f),"")
            val objSaveData=RetrofitService().getRetrofit(UrlAPI.URL_BACK_PY).create(ApiService::class.java).InsertData(pes);

            if(objSaveData.isSuccessful)
            {
                withContext(Dispatchers.Main)
                {
                    ToastMessage().toast(
                        this@MainActivity,
                        "Datos guardados correctamente"
                    )
                }
            }
        }
    }

    fun ramdom_num_float(min: Float,max:Float):Float
    {
        return Random.nextFloat() * (max - min) + min;
    }

    fun init()
    {
        change_state("Cerrado");
        binding.btnConectarws.setOnClickListener { connect_web_scoket() }

        binding.btnAum.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                try {
                    val objSaveData = RetrofitService().getRetrofit(UrlAPI.URL_BACK_C)
                        .create(ApiService::class.java).aum();
                    if(objSaveData.isSuccessful)
                    {
                        message_action();
                    }
                }catch (ex:Exception){
                    Log.i("PieSocket",ex.message.toString())
                }
            }
        }

        binding.btnDes.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                val objSaveData=RetrofitService().getRetrofit(UrlAPI.URL_BACK_C).create(ApiService::class.java).des();
                if(objSaveData.isSuccessful)
                {
                    message_action();
                }
            }
        }

        binding.btnTara.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                val objSaveData=RetrofitService().getRetrofit(UrlAPI.URL_BACK_C).create(ApiService::class.java).tara();
                if(objSaveData.isSuccessful)
                {
                    message_action();
                }
            }
        }
    }

    suspend fun message_action()
    {
        withContext(Dispatchers.Main)
        {
            ToastMessage().toast(
                this@MainActivity,
                "Accion completada correctamente"
            )
        }
    }

    fun change_values(obj_data: data_socket)
    {
        binding.kgpesobruto.text="PESO BRUTO: "+obj_data.peso_bruto+" KG";
        binding.kgtara.text="TARA: "+obj_data.peso_bruto+" KG";
        binding.kgprinc.text=obj_data.peso_actual+" KG";
    }

    fun change_state(state:String){
        binding.txtstate.text="Estado: "+state;
    }

    fun save_data(data: data_socket)
    {
        CoroutineScope(Dispatchers.IO).launch {
            val pes=pesos_model(0,data.peso_bruto.replace(",",".").toFloat() ,data.peso_actual.replace(",",".").toFloat(),data.tara.replace(",",".").toFloat(),"")
            val objSaveData=RetrofitService().getRetrofit(UrlAPI.URL_BACK_PY).create(ApiService::class.java).InsertData(pes);

            if(objSaveData.isSuccessful)
            {
                withContext(Dispatchers.Main)
                {
                    ToastMessage().toast(
                        this@MainActivity,
                        "Datos guardados correctamente"
                    )

                    ToastMessage().toast(
                        this@MainActivity,
                        "Por favor retire el plato de la balanza"
                    )

                }
            }
        }
    }

    fun connect_web_scoket()
    {
        val client: OkHttpClient =  OkHttpClient()
        val request: Request = Request
            .Builder()
            .url(URL_SOCKET)
            .build()
        var objw=WebSocketListener()
        objw.function_change_data= { change_values(it) }
        objw.function_state_websocket={change_state(it)}
        objw.function_guardar_data={save_data(it)}
        val listener = objw
        val ws: WebSocket = client.newWebSocket(request, listener)
    }


}