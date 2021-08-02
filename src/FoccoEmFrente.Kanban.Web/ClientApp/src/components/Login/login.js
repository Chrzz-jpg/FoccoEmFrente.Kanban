import React, { useState } from "react";
import HttpRequest from "../../utils/HttpRequest/Http-request";

export default function Login({ history }) {

  const [formLogin, setFormLogin] = useState({ email: "", password: ""});

  const setEmail = (event) => {
    setFormLogin({...formLogin, email: event.target.value})
  }

  const setPassword = (event) => {
    setFormLogin({...formLogin, password: event.target.value });
  }

  const onLogin = async (event) => {
    event.preventDefault();

    const request = new HttpRequest("account/login", "POST");

    request.setBody(formLogin);

    const response = await request.send();

    if (!response.ok) {
      window.alert(response);
      return;
    }

    localStorage.setItem("token", response.data);

    history.push("/");
  };

  const onRegister = () => {
    history.push("/register");
  };

  return (
    <div style={{ width: "450px" }}>
      <p>
        Bem vindo ao <strong>Sunday.com</strong>, o melhor sistema para aprender
        C# e React (rsrs!)!
      </p>
      <form onSubmit={onLogin}>
        <label htmlFor="email">E-mail</label>
        <input
          id="email"
          type="email"
          placeholder="E-mail"
          value={formLogin.email}
          onChange={setEmail}
        ></input>
        <label htmlFor="password">Senha</label>
        <input
          id="password"
          type="password"
          placeholder="Senha"
          value={formLogin.password}
          onChange={setPassword}
        ></input>

        <button className="btn btn-primary">Entrar</button>

        <button className="btn btn-secundary" onClick={onRegister}>
          {" "}
          Registrar{" "}
        </button>
      </form>
    </div>
  );
}
