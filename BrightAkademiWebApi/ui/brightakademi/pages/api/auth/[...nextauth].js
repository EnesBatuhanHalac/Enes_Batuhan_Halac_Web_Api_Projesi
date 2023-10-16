import CredentialsProvider from "next-auth/providers/credentials";


import React from 'react'

export default NextAuth({
    providers: [
        CredentialsProvider({
          // The name to display on the sign in form (e.g. "Sign in with...")
          name: "Credentials",
          // `credentials` is used to generate a form on the sign in page.
          // You can specify which fields should be submitted, by adding keys to the `credentials` object.
          // e.g. domain, username, password, 2FA token, etc.
          // You can pass any HTML attribute to the <input> tag through the object.
          credentials: {
            username: { label: "Username", type: "text", placeholder: "jsmith" },
            password: { label: "Password", type: "password" }
          },
          async authorize(credentials, req) {
            
            const res = await fetch(`${process.env.API_URL}/auth/login`,{
                method:"POST",
                headers:{"Content-Type":"application/json"},
                body:credentials
            })

            const user =await res.json();

            if (user) {
                return user;
            }else{
                return null
            }
          }
        })
      ]
      
})
