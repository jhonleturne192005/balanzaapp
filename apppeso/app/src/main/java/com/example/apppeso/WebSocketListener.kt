package com.example.apppeso

import android.util.Log
import com.example.apppeso.data_response.data_socket
import com.example.apppeso.data_response.pesos_response
import com.google.gson.Gson
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import okhttp3.Response
import okhttp3.WebSocket
import okhttp3.WebSocketListener

class WebSocketListener : WebSocketListener()
{
    public var function_change_data:(obj_data: data_socket)-> Unit={};
    public var function_state_websocket:(state:String) -> Unit={};
    public var function_guardar_data:(data:data_socket) -> Unit={};

    override fun onOpen(webSocket: WebSocket, response: Response) {
        CoroutineScope(Dispatchers.Main).launch {
            function_state_websocket("Activo");
        }
        webSocket.send("Hello World!")
        Log.e("burak","baglandi")
    }

    override fun onMessage(webSocket: WebSocket, text: String) {

        output("Received : $text")

        if(text.contains("peso_bruto")){

            val pp:data_socket= Gson().fromJson(text, data_socket::class.java);
            Log.i("PieSocket",pp.peso_bruto);
            Log.i("PieSocket",pp.peso_actual );
            Log.i("PieSocket",pp.tara);

            var pa:Float=pp.peso_actual.replace(",",".").toFloat();

            if(pa>=5 && pa<=6) {
                CoroutineScope(Dispatchers.Main).launch {
                    function_guardar_data(pp);
                }
            }

            CoroutineScope(Dispatchers.Main).launch {
                try {
                    function_change_data(pp);
                    function_state_websocket("Activo");
                }
                catch (ex:Exception){
                    Log.i("PieSocket",ex.message.toString());
                }
            }
        }
    }



    override fun onClosing(webSocket: WebSocket, code: Int, reason: String) {
        webSocket.close(NORMAL_CLOSURE_STATUS, null)
        output("Closing : $code / $reason")
        CoroutineScope(Dispatchers.Main).launch {
            function_state_websocket("Cerrado");
        }
    }


    override fun onFailure(webSocket: WebSocket, t: Throwable, response: Response?) {
        output("Error : " + t.message+" fsda")
        CoroutineScope(Dispatchers.Main).launch {
            function_state_websocket("Error");
        }
    }

    fun output(text: String?) {
        Log.d("PieSocket", text!!)
    }

    companion object {
        private const val NORMAL_CLOSURE_STATUS = 1000
    }

}