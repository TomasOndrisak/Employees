import http from './Http'

class LastPoisitions {
  getAll(employeeId: number): Promise<any> {
    return http.get("api/lastpositions/" + employeeId);
  }
}
export default new LastPoisitions();