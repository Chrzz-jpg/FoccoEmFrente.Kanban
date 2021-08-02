import React, { useState } from "react";

export default function Register({ history }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const onRegister = async (event) => {
      event.preventDefault();

     const response = await fetch("/api/account/register", {
         method: "POST",
         headers: {
            "Content-Type": "application/json",
            "Accept" : "application/json"
         },
         body: JSON.stringify({
            email: email,
            password: password,
            confirmPassword: confirmPassword
         })
      });

      const responseContent = await response.json();

      if(!response.ok){
         window.alert(responseContent);
         return;
      }

      localStorage.setItem("token", responseContent);
      history.push("/");

      console.log(response);
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
