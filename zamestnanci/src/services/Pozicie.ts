import http from './Http'

class Pozicie {
  getAll(): Promise<any> {
    return http.get("api/pozicie");
  }

    delete(poziciaId: any): Promise<any> {
    return http.delete("api/pozicie/" + poziciaId);
  }

  PostData(data: any): Promise<any> {
    return http.post("api/pozicie/", data);
  }
}
export default new Pozicie();