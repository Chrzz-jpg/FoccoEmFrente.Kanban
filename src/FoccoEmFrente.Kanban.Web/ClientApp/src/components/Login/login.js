import React, { useState } from "react";

export default function Login({ history }) {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onLogin = async (event) => {
   event.preventDefault();

  const response = await fetch("/api/account/login", {
      method: "POST",
      headers: {
         "Content-Type": "application/json",
         "Accept" : "application/json"
      },
      body: JSON.stringify({
         email: email,
         password: password      
      })
   });

   const responseContent = await response.json();

   if(!response.ok){
      window.alert(responseContent);
      return;
   }

   localStorage.setItem("token", responseContent);
   history.push("/home");

   console.log(response);
}

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

        <button className="btn btn-primary">Entrar</button>

        <button className="btn btn-secundary" onClick={onRegister}>
          {" "}
          Registrar{" "}
        </button>
      </form>
    </div>
  );
}
