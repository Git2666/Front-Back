<template>
    <div class="login-container">
      <div class="login-box">
        <h2>Login</h2>
        <p v-if="errorMessage">{{ errorMessage }}</p>
        <form @submit.prevent="handleLogin">
          <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" id="username" v-model="loginForm.username" required>
          </div>
          <div class="form-group">
            <label for="password">Password:</label>
            <input type="password" id="password" v-model="loginForm.password" required>
          </div>
          <button type="submit">Login</button>
        </form>
      </div>
    </div>
</template>
   
<script>
  import { reactive, ref } from 'vue';
  import { useRouter } from 'vue-router';
  import axios from 'axios';
  export default {
    setup() {
      const loginForm = reactive({
        Username: '',
        Password: ''
      });
      const errorMessage = ref('');
      const router = useRouter();
      async function handleLogin() {
        try{
          const response = await axios.post('http://150.158.121.115:1080/api/Login', loginForm)
          localStorage.setItem('token', response.data.token);
          router.push('/center');
        }
        catch (error) {
          errorMessage.value = 'Invalid username or password';
        }
      }
   
      return {
        loginForm,
        errorMessage,
        handleLogin
      };
    }
  };
</script>
   
<style scoped>
  .login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }
   
  .login-box {
    width: 100%;
    max-width: 300px;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
   
  .form-group {
    margin-bottom: 15px;
    margin-right: 15px;
  }
   
  .form-group label {
    display: block;
    margin-bottom: 5px;
  }
   
  .form-group input[type="text"],
  .form-group input[type="password"] {
    width: 100%;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 16px;
  }
   
  button[type="submit"] {
    width: 100%;
    padding: 10px;
    border: none;
    border-radius: 4px;
    background-color: #5cb85c;
    color: white;
    cursor: pointer;
  }
   
  button[type="submit"]:hover {
    background-color: #4cae4c;
  }
</style>