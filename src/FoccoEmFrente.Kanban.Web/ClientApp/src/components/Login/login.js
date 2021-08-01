import React from "react";

export default function Login({history}) {

   const onRegister = () => {
      history.push("/register");
  }

   return (
      <div style={{width: "450px"}}>
         <p>Bem vindo ao <strong>Sunday.com</strong>, o melhor sistema para aprender C# e React (rsrs!)!</p>
         <form>
            <label htmlFor="email">E-mail</label>
            <input id="email" type="email" placeholder="E-mail"></input>
            <label htmlFor="password">Senha</label>
            <input id="password" type="password" placeholder="Senha"></input>

            <button className="btn btn-primary">Entrar</button>
            
            <button className="btn btn-secundary" onClick={onRegister} > Registrar </button>
         </form>
      </div>
   );
}