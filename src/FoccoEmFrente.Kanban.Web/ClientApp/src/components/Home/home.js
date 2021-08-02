import React, { useEffect, useState } from "react";
import Pipe from "./Pipe"
import "./home.css"
export default function Home({ history }) {

   const [activities, setActivities] = useState([]);
   const token = localStorage.getItem("token");
   if(!token) history.push("/login");

   const loadActivity = async () => {
      const response = await fetch("/api/activities", {
          method: "GET",
          headers: {
             "Content-Type": "application/json",
             "Accept" : "application/json",
             "Authorization": `Bearer ${token}`
          }
       });
    
       const responseContent = await response.json();
    
       if(!response.ok){
          window.alert(["Não foi possível encontrar atividaddes", responseContent]);
          return;
       }
       setActivities(responseContent);
   }

  const onSair = () => {
    localStorage.removeItem("token");
    history.push("/login");
  };

//utilizando um método assincrono para o callback
  useEffect( () => {
     async function fetchData() {
        await loadActivity();
     }

     fetchData();
  }, []);

  return (
    <div style={{ width: "800px" }}>
      <p>
        Bem vindo ao <strong>Sunday.com</strong>!
      </p>
      <p>
        Esse é seu canvas para organizar suas atividades. Crie novas atividades
        e mantenha elas sempre atualizadas!
      </p>
      <div className="canvas">
         <Pipe activities={activities} status={0}/>
         <Pipe activities={activities} status={1}/>
         <Pipe activities={activities} status={2}/>
      </div>
      <button className="btn btn-primary">
         Adicionar nova atividade
      </button>
      <button className="btn btn-secundary" onClick={onSair}>
         Sair
      </button>
    </div>
  );
}
