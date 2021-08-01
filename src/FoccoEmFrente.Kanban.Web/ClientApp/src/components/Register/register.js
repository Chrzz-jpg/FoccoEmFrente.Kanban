import React from "react";

export default function Register({history}) {
    const onVoltar = () => {
        history.push("/login");
    }
   return (
      <div style={{width: "450px"}} >
         <p>Crie sua conta no <strong>Sunday.com</strong>, o melhor sistema para aprender C# e React (rsrs!)!</p>
         <form>
            <label htmlFor="email">E-mail</label>
            <input id="email" type="email" placeholder="E-mail"></input>
            
            <label htmlFor="password">Senha</label>
            <input id="password" type="password" placeholder="Senha"></input>

            <label htmlFor="password">Confirme sua senha</label>
            <input id="confirmPassword" type="password" placeholder="Confirme sua senha"></input>

            <button className="btn btn-primary">Registrar</button>

            <button className="btn btn-secundary" onClick={onVoltar}>Voltar</button>
         </form>
      </div>
   );
}