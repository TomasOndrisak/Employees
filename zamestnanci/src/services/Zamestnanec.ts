import http from './Http'

class Zamestnanec {

  getAll(): Promise<any> {
    return http.get("api/Zamestnanci/archivovany/false");
  }
  getArchivovany(): Promise<any> {
    return http.get("api/Zamestnanci/archivovany/true");
  }
  delete(zamestnanecId: any): Promise<any> {
    return http.delete(`api/Zamestnanci/${zamestnanecId}`);
  }

  getId(id: any): Promise<any>{
    return http.get('api/Zamestnanci/'+id);
  }

  archivuj(id: any, data:any): Promise<any>{
    return http.put("/archivuj/"+id, data)
    
  }
  
  Edit(id: any, data: any): Promise<any>{
    return http.put("api/Zamestnanci/"+id, data);
  }

  Post(data: any): Promise<any>{
      return http.post("api/Zamestnanci/", data);
    }
 
}
export default new Zamestnanec();