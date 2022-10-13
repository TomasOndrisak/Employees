import http from './Http'

class Predosle {
    getAll( zamestnanecId:any ): Promise<any> {
      return http.get("api/Predoslepozicie/"+ zamestnanecId);
    }
  }
  export default new Predosle();