class Rank:
    def __init__(self) -> None:
        # Empty constructor (can be omitted if not needed)
        pass

    # Properties
    @property
    def Rank_Number(self) -> int:
        return self.rank_num

    @Rank_Number.setter
    def Rank_Number(self, value: int) -> None:
        self.rank_num = value

    @property
    def Rank_Name(self) -> str:
        return self.rank_nam

    @Rank_Name.setter
    def Rank_Name(self, value: str) -> None:
        self.rank_nam = value
