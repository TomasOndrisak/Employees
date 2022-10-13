import http from './Http'

class Positions {
  getAll(): Promise<any> {
    return http.get("api/positions");
  }

  delete(positionId: number): Promise<any> {
    return http.delete("api/positions/" + positionId);
  }

  PostData(data: any): Promise<any> {
    return http.post("api/positions/", data);
  }
}
export default new Positions();