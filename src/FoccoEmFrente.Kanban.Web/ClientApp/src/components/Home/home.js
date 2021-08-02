import React, { useEffect, useState } from "react";
import Pipe from "./Pipe";
import "./home.css";
import HttpRequest from "../../utils/HttpRequest/Http-request";

export default function Home({ history }) {
  const [activities, setActivities] = useState([]);
  const token = localStorage.getItem("token");
  if (!token) history.push("/login");

  const loadActivity = async () => {
    const response = await new HttpRequest("activities", "GET")
      .setToken(token)
      .send();
    if (!response.ok) {
      window.alert([
        "Não foi possível encontrar atividaddes",
        response.errorMessage,
      ]);
      return;
    }
    setActivities(response.data);
  };

  const onSair = () => {
    localStorage.removeItem("token");
    history.push("/login");
  };

  const addActivity = async () => {
    const activity = {
      title: "Nova Atividade",
      status: 0,
    };
    const response = await new HttpRequest("activities", "POST")
      .setBody(activity)
      .setToken(token)
      .send();

    if (!response.ok) {
      window.alert([
        "Não foi possível insrir a atividade",
        response.errorMessage,
      ]);
      return;
    }

    setActivities([...activities, response.data]);
  };

  const updateActivity = async (activity) => {
    const response = await new HttpRequest("activities", "PUT")
      .setBody(activity)
      .setToken(token)
      .send();

    if (!response.ok) {
      window.alert([
        "Não foi possível atualizar a atividade",
        response.errorMessage,
      ]);
      await loadActivity();
      return;
    }
  };

  const updateActivityStatus = async (activityId, status) => {
    const action = status === 0 ? "todo" : status === 1 ? "doing" : "done";

    const response = await new HttpRequest(
      `activities/${activityId}/${action}`,
      "PUT"
    )
      .setToken(token)
      .send();

    if (!response.ok) {
      window.alert([
        "Não foi possível atualizar o status da atividade",
        response.errorMessage,
      ]);
      return;
    }
    
    //evita um request ao servidor, fazendo apenas um ao clonar o array de activities
    activities.find((a) => a.id === activityId).status = status;
    setActivities([...activities]); 
  };

  const deleteActivity = async (activity) => {
    const response = await new HttpRequest(
      `activities/${activity.id}`,
      "DELETE"
    )
      .setToken(token)
      .send();

    if (!response.ok) {
      window.alert([
        "Não foi possível deletar a atividade",
        response.errorMessage,
      ]);
      return;
    }

    setActivities(activities.filter((a) => a.id !== activity.id));
  };

  //utilizando um método assincrono para o callback
  useEffect(() => {
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
        {[0, 1, 2].map((status, index) => {
          return (
            <Pipe
              key={index}
              activities={activities}
              status={status}
              onDelete={deleteActivity}
              onUpdate={updateActivity}
              onActivityDrop={(activityId) =>
                updateActivityStatus(activityId, status)
              }
            />
          );
        })}
      </div>
      <button className="btn btn-primary" onClick={addActivity}>
        Adicionar nova atividade
      </button>
      <button className="btn btn-secundary" onClick={onSair}>
        Sair
      </button>
    </div>
  );
}
