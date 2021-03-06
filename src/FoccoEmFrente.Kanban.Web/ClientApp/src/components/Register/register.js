import React, { useState } from "react";
import HttpRequest from "../../utils/HttpRequest/Http-request";

export default function Register({ history }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const onRegister = async (event) => {
      event.preventDefault();

      const response = await new HttpRequest("account/register", "POST")
          .setBody({
            email:email,
            password:password,
            confirmPassword:confirmPassword
          })
          .send();

      if(!response.ok){
         window.alert(response.errorMessage);
         return;
      }

      localStorage.setItem("token", response.data);
      history.push("/");
   }

  const onVoltar = () => {
    history.push("/login");
  
   };

  return (
    <div
      style={{
        width: "450px",
      }}
    >
      <p>
        Crie sua conta no
        <strong>Sunday.com</strong>, o melhor sistema para aprender C# e React
        (rsrs!)!
      </p>
      <form onSubmit={onRegister}>
        <label htmlFor="email">E-mail</label>
        <input
          id="email"
          type="email"
          placeholder="E-mail"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        ></input>

        <label htmlFor="password">Senha</label>
        <input
          id="password" 
          type="password" 
          placeholder="Senha"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
          >      
      </input>

        <label htmlFor="password">Confirme sua senha</label>
        <input
          id="confirmPassword"
          type="password"
          placeholder="Confirme sua senha"
          value={confirmPassword}
          onChange={(event) => setConfirmPassword(event.target.value)}
        ></input>

        <button className="btn btn-primary">
           Registrar
        </button>

        <button className="btn btn-secundary" onClick={onVoltar}>
          Voltar
        </button>
      </form>
    </div>
  );
}
