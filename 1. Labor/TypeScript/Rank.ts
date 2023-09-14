class Rank {
  // Properties
  private rank_num: number; // adatelem
  private rank_nam: string; // adatelem

  public Rank_Number: number;
  public Rank_Name: string;

  constructor() {
    // Constructor
    this.Rank_Number = 0;
    this.Rank_Name = '';
  }

  // Property descriptions
  get Rank_Num(): number {
    return this.rank_num;
  }

  set Rank_Num(value: number) {
    this.rank_num = value;
  }

  get Rank_Nam(): string {
    return this.rank_nam;
  }

  set Rank_Nam(value: string) {
    this.rank_nam = value;
  }
}
