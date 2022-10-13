import axios, { AxiosInstance } from "axios";  
      
const API: AxiosInstance = axios.create({  
      baseURL: "https://localhost:5001/"
     });
     
export default API;
    
