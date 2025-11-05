export interface GetTaskDto {
    id: number;
    title: string;
    description: string | null;
    status: string;
}